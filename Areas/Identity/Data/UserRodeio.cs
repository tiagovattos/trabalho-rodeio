using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace trabalho_rodeio.Areas.Identity.Data;

// Add profile data for application users by adding properties to the UserRodeio class
public class UserRodeio : IdentityUser
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
}

