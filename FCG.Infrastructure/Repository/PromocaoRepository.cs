﻿using FCG.Core.Entity;
using FCG.Core.Repository;

namespace FCG.Infrastructure.Repository
{
    public class PromocaoRepository : EFRepository<Promocao>, IPromocaoRepository
    {
        public PromocaoRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
