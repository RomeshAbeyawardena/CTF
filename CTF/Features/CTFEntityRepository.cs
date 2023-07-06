using LinqKit;
using RST.EntityFrameworkCore;
using System.Reactive.Subjects;

namespace CTF.Features
{
    public class CTFEntityRepository<T> : EntityFrameworkRepositoryBase<CTFDbContext, T>
    where T : class
    {
        public CTFEntityRepository(CTFDbContext context, ISubject<ExpressionStarter<T>> subject) : base(context, subject)
        {
            base.OnReset.Subscribe(q => q.DefaultExpression = a => true);
        }
    }
}
