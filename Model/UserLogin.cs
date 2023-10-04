﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GameHall.Model
{
    public class UserLogin
    {
        public long Id { get; set; }
        
        public string Nome { get; set; } = string.Empty;
       
        public string Usuario { get; set; } = string.Empty;
       
        public string Senha { get; set; } = string.Empty;

        public DateOnly? DataNascimento { get; set; }

        public string Token { get; set; } = string.Empty;

    }
}
