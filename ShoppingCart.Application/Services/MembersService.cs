using AutoMapper;
using ShoppingCart.Application.Interfaces;
using ShoppingCart.Application.ViewModels;
using ShoppingCart.Domain.Interfaces;
using ShoppingCart.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.Services
{
    public class MembersService : IMembersService
    {
        public IMembersRepository _membersRepo;
        private IMapper _mapper;

        public MembersService(IMembersRepository membersRepo, IMapper mapper)
        {
            _membersRepo = membersRepo;
            _mapper = mapper;
        }

        public void AddMember(MemberViewModel m)
        {
            var mem = _mapper.Map<Member>(m);
            _membersRepo.AddMembers(mem);

        }
    }
}
