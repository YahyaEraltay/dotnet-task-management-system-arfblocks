namespace Station.Infrastructure.Services.TestServices;

public class DbContextOperations<TEntity> where TEntity : CoreEntity
{
    private readonly ApplicationDbContext _dbcontext;
    public DbContextOperations(ApplicationDbContext dbContext)
    {
        dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        _dbcontext = dbContext;
    }

    public async Task Create<TAnotherEntity>(TAnotherEntity entity) where TAnotherEntity : CoreEntity
    {
        _dbcontext.Set<TAnotherEntity>().Add(entity);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Create(TEntity entity)
    {
        _dbcontext.Set<TEntity>().Add(entity);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Update<TAnotherEntity>(TAnotherEntity entity) where TAnotherEntity : CoreEntity
    {
        _dbcontext.Set<TAnotherEntity>().Update(entity);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task Update(TEntity entity)
    {
        _dbcontext.Set<TEntity>().Update(entity);
        await _dbcontext.SaveChangesAsync();
    }

    public async Task<TAnotherEntity> GetById<TAnotherEntity>(Guid id) where TAnotherEntity : CoreEntity
    {
        return await _dbcontext.Set<TAnotherEntity>().Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    public async Task<TEntity> GetById(Guid id)
    {
        return await _dbcontext.Set<TEntity>().Where(a => a.Id == id).FirstOrDefaultAsync();
    }

    private IQueryable<TEntity> query;
    public DbContextOperations<TEntity> Query(Guid id)
    {
        query = _dbcontext.Set<TEntity>().Where(a => a.Id == id);
        return this;
    }

    public DbContextOperations<TEntity> Include<TProperty>(System.Linq.Expressions.Expression<Func<TEntity, TProperty>> navigationPropertyPath)
    {
        query = query.Include(navigationPropertyPath);
        return this;
    }

    public async Task<TEntity> Execute()
    {
        return await query.FirstOrDefaultAsync();
    }
}