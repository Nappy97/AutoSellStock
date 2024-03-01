
#region
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
#endregion

namespace AutoStock.Data;

public class DbContextFactory
{
    public static string ConnectionString => "Data Source=.;Initial Catalog=AutoStock;Persist Security Info=True;User ID=sa;Password=1234;Trust Server Certificate=True";

    private static PooledDbContextFactory<AutoStockContext>? _factory;

    public static AutoStockContext Create()
    {
        if (_factory == null)
            InitializeFactory();

        return _factory!.CreateDbContext();
    }

    private static void InitializeFactory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<AutoStockContext>();

        // 콘솔에 로그 출력
#if DEBUG
        optionsBuilder.UseLoggerFactory(AutoStockContextLoggerFactory.GetInstance(
            nameof(LogPath.Console),
            nameof(LogPath.Debug),
            @"AutoStockContext.log"));
#endif

        // 엔터티 상태를 트랙킹하지 않음
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        // QuerySplittingBehavior
        var querySplittingBehavior = QuerySplittingBehavior.SplitQuery;

        var options = optionsBuilder
            .UseSqlServer(
                ConnectionString,
                x => x.UseQuerySplittingBehavior(querySplittingBehavior))
            .Options;

        _factory = new PooledDbContextFactory<AutoStockContext>(options);
    }
}