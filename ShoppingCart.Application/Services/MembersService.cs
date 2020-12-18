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
        { /*
            Member newMember = new Member()
            {
                Email = m.Email,
                FirstName = m.FirstName,
                LastName = m.LastName
            };

            //As soon as the user clicked on  the register button a record will go in the asp.netUsers and another record will be stored 
            //in the table called Members.
            //asp.netUsers->use it for login info

            _membersRepo.AddMembers(newMember);

            */

            //Member >>> MemberViewMdodel
            var mem = _mapper.Map<Member>(m);
            _membersRepo.AddMembers(mem);
        }
    }
}
