using AC.Domain;
using AC.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AC.Persistence.Configuration
{
    public class DbInitializer
    {
        private DataBaseContext context;

        public DbInitializer(DataBaseContext dataContext)
        {
            context = dataContext;
        }

        public void Initialize()
        {

            context.Database.Migrate();
 
            if (!context.Set<Status>().Any())
            {
                Status[] listStatus = AddStatus();
                context.AddRange(listStatus);
            }

            if (!context.Set<Person>().Any())
            {
                PersonPhysical person = new PersonPhysical();
                person.FullName = "Elvis";
                person.Birth = DateTime.Now;
                person.Document = "446.866.553-07";

                context.Add(person);

                PersonLegal legal = new PersonLegal();
                legal.FantasyName = "Solucoes Integradas El";
                legal.SocialReason = "EL Solution";
                legal.Document = "54.354.255/0001-81";

                context.Add(person);
            }

            if (!context.Set<TransactionsType>().Any())
            {
                TransactionsType[] list = AddTransactionsType();
                context.AddRange(list);
            }

            context.SaveChanges();

        }

        private static TransactionsType[] AddTransactionsType()
        {
            return new TransactionsType[]
            {
                new TransactionsType { Name ="APORTE" , Description = "Valor creditado diretamente a uma conta matriz" },
                new TransactionsType { Name ="TRANSFERÊNCIA " , Description = "Valor transferido para conta abaixo da conta de origem, mas nao pode ser transferido para conta matriz" },
                new TransactionsType { Name ="CARGAS" , Description = "Valor creditado em qualquer conta que nao seja a conta matriz" },
                new TransactionsType { Name ="ESTORNO" , Description = "Valor estornado de qualquer conta. Para a conta matriz deve ser digitado o codigo gerado."}
            };
        }

        private static Status[] AddStatus()
        {
            return new Status[]
                {
                    new Status { Name = "ATIVA" },
                    new Status { Name = "DESATIVADA" },
                    new Status { Name = "BLOQUEADA" }
                };
        }

    }
}
