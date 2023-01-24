using Caravan.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Configurations;

public class AdminConfiguration : IEntityTypeConfiguration<Administrator>
{
    public void Configure(EntityTypeBuilder<Administrator> builder)
    {
        builder.HasData(new Administrator()
        {
            Id = 1,
            FirstName = "Normadjon",
            LastName = "G'offorov",
            Email= "admin@gmail.com",
            PasswordHash = "$2a$11$pUC4LQVORynSuk0xn/Wl9ujn3e8NVGIa9rs8WUliW4USW5FY/BhOG",
            Salt = "f1fd3ecc-32c8-430d-ae6d-288eb2753c43",
            ImagePath = "",
            PhoneNumber = "+998330670027",
            PassportSeria = "AC",
            PassportNumber = "2518815",
            CreatedAt= DateTime.UtcNow,
            UpdatedAt= DateTime.UtcNow
        });
    }
}
