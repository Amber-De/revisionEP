using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ShoppingCart.Application.ViewModels;

namespace Presentation.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ShoppingCart.Application.ViewModels.OrderDetailsViewModel> OrderDetailsViewModel { get; set; }
    }
}
