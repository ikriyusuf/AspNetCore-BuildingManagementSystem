﻿using BuildingManagement.Application.Extension;

namespace BuildingManagement.Application.Features.Commands.UserCommands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommandRequest, CreateUserCommandResponse>
    {
        private readonly IWriteUserRepository _writeuserRepository;
        public CreateUserCommandHandler(IWriteUserRepository writeuserRepository)
        {
            _writeuserRepository = writeuserRepository;
        }
        public Task<CreateUserCommandResponse> Handle(CreateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = new User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                TcKimlikNo = request.TcKimlikNo,
                PhoneNumber = request.PhoneNumber,
                Email = request.Email,
                PasswordHash = request.PasswordHash,
                Role = request.Role
            };
            _writeuserRepository.Create(user);
            _writeuserRepository.SaveChangesAsync();
            return Task.FromResult(new CreateUserCommandResponse().ToCreateMessage(user.Id));
        }
    }
}
