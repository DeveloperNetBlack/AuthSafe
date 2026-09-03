using AuthSafe.DomainModel.Dtos.Role;
using AuthSafe.DomainModel.Model;
using AuthSafe.DomainModel.ValueObjects;
using AuthSafe.DomainService.IRepositories.IPageCompanyRepositories;
using AuthSafe.DomainService.IRepositories.IRolePermissionRepositories;
using AuthSafe.DomainService.IRepositories.IRoleRepositories;
using AuthSafe.DomainService.IServices;
using AuthSafe.DomainService.Transactions;
using AuthSafe.Infrastructure.CrossCutting.Constants;
using AuthSafe.Infrastructure.CrossCutting.Wrappers;
using MediatR;

namespace AuthSafe.ApplicationService.Features.RoleFeatures.Commands.RoleCreate
{
    internal class RoleCreateCommandHandler : IRequestHandler<RoleCreateCommandRequest, MsgResponse<object?>>
    {
        private readonly ICurrentSessionService CurrentSessionService;
        private readonly IMessageService MessageService;
        private readonly IRoleCreateRepository RoleCreateRepository;
        private readonly IRoleVerifyCodeAndNameRepository RoleVerifyCodeAndNameRepository;
        private readonly IRolePermissionCreateRepository RolePermissionCreateRepository;
        private readonly IPageCompanyCreateNotExistsRepository PageCompanyCreateNotExistsRepository;
        private readonly IUnitOfWork UnitOfWork;

        public RoleCreateCommandHandler(
            ICurrentSessionService CurrentSessionService,
            IMessageService MessageService,
            IRoleCreateRepository RoleCreateRepository,
            IRoleVerifyCodeAndNameRepository RoleVerifyCodeAndNameRepository,
            IRolePermissionCreateRepository RolePermissionCreateRepository,
            IPageCompanyCreateNotExistsRepository PageCompanyCreateNotExistsRepository,
            IUnitOfWork UnitOfWork
            )
        {
            this.CurrentSessionService = CurrentSessionService;
            this.MessageService = MessageService;
            this.RoleCreateRepository = RoleCreateRepository;
            this.RoleVerifyCodeAndNameRepository = RoleVerifyCodeAndNameRepository;
            this.RolePermissionCreateRepository = RolePermissionCreateRepository;
            this.PageCompanyCreateNotExistsRepository = PageCompanyCreateNotExistsRepository;
            this.UnitOfWork = UnitOfWork;
        }

        public async Task<MsgResponse<object?>> Handle(RoleCreateCommandRequest Request, CancellationToken CancellationToken)
        {
            var MsgResponse = new MsgResponse<object?>();
            try
            {

                RoleCreateDto roleCreateDto = new RoleCreateDto
                {
                    IdCompany = Request.CompanyID,
                    RoleCode = Request.RoleCode,
                    RoleName = Request.RoleName,
                    RoleDescription = Request.RoleDescription,
                    IdState = (short)Request.StateID,
                    IdUserName = CurrentSessionService.UserName
                };

                var Verify = await RoleVerifyCodeAndNameRepository.VerifyCodeAndNameAsync(roleCreateDto, CancellationToken);
                if (Verify == VerifyRegistryConst.Role.OK)
                {
                    await UnitOfWork.BeginTransactionAsync(CancellationToken);
                    int RecordAffected = await RoleCreateRepository.CreateAsync(roleCreateDto, CancellationToken);
                    if (RecordAffected > 0)
                    {
                        var PageIDs = Request.RolePermission.Select(s => s.PageID).Distinct().ToList();
                        foreach (var PageID in PageIDs)
                        {
                            var PageCompany = new PageCompany()
                            {
                                IdPage = PageID,
                                IdCompany = Request.CompanyID
                            };
                            await PageCompanyCreateNotExistsRepository.CreateNotExistsAsync(PageCompany, CancellationToken);

                            foreach (var Item in Request.RolePermission.Where(w => w.PageID == PageID).ToList())
                            {
                                await RolePermissionCreateRepository.CreateAsync(new RolePermission
                                {
                                    IdCompany = Request.CompanyID,
                                    IdRole = roleCreateDto.IdRole,
                                    IdPage = Item.PageID,
                                    IdPageAction = Item.PageActionID
                                });
                            }
                        }

                        MsgResponse.Type = MessageTypeConst.SUCCESS;
                        MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.SATISFACTORY_INSERT);
                        MsgResponse.Data = new
                        {
                            roleCreateDto.IdRole,
                            roleCreateDto.RoleCode,
                            roleCreateDto.RoleName
                        };

                        await UnitOfWork.CommitTransactionAsync(CancellationToken);
                    }
                    else
                    {
                        MsgResponse.Type = MessageTypeConst.ERROR;
                        MsgResponse.Message = MessageService.GetMessageResult(MessageDescriptionConst.ERROR_INSERT);
                    }
                }
                else
                {
                    MsgResponse.Type = MessageTypeConst.WARNING;
                    MsgResponse.Message = MessageService.GetMessageResult(Verify == VerifyRegistryConst.Role.NAME_EXISTS ? MessageDescriptionConst.EXIST_ROLE_ROLENAME : MessageDescriptionConst.EXIST_ROLE_ROLECODE);
                }
            }
            catch (ArgumentNullException ex)
            {
                MsgResponse.Type = MessageTypeConst.WARNING;
                MsgResponse.Message = "El codigo de rol es obligatorio " + ex.Message;
            }
            catch (Exception ex)
            {
                await UnitOfWork.RollbackTransactionAsync(CancellationToken);
                MsgResponse.Type = MessageTypeConst.ERROR;
                MsgResponse.Message = $"{MessageService.GetMessageResult(MessageDescriptionConst.ERROR_OPERATION)}:{ex.Message}";

            }
            return MsgResponse;
        }
    }
}
