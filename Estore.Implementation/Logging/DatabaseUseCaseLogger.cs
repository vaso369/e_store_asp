using Estore.Application;
using Estore.DataAccess;
using Estore.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estore.Implementation.Logging
{
    public class DatabaseUseCaseLogger : IUseCaseLogger
    {
        private readonly EstoreContext _context;

        public DatabaseUseCaseLogger(EstoreContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new UseCaseLogs
            {
                Actor = actor.Identity,
                Data = JsonConvert.SerializeObject(useCaseData),
                Date = DateTime.UtcNow,
                UseCaseName = useCase.Name
            });
            _context.SaveChanges();
        }
    }
}
