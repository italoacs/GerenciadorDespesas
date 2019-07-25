using GerenciadorDespesas.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GerenciadorDespesas.Mapeamento
{
    public class SalariosMap : IEntityTypeConfiguration<TipoDespesas>
    {
        public void Configure(EntityTypeBuilder<TipoDespesas> builder)
        {
            throw new NotImplementedException();
        }
    }
}
