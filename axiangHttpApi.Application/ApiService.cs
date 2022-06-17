using Furion.DynamicApiController;
using Microsoft.Extensions.Options;
using Furion;
using Microsoft.AspNetCore.Mvc;
using SqlSugar;

namespace axiangHttpApi.Application
{
    public class ApiService:IDynamicApiController
    {
        private readonly AppInfoOptions _options;

        private readonly ISqlSugarClient _db;

        public ApiService(
            IOptions<AppInfoOptions> options,
            ISqlSugarClient db)
        {
            _options = options.Value;
            _db = db;
        }
        /// <summary>
        /// 接口：A
        /// </summary>
        /// <returns></returns>
        public string GetA([FromQuery]string id)
        {
            var appoptions = App.GetOptions<AppInfoOptions>();
            return $"{_options.Name},{_options.Version},{_options.Author},{appoptions.Name}";
        }

        public AppInfoOptions PostB([FromBody]string id)
        {
            var appoptions = App.GetOptions<AppInfoOptions>();
            return _options;
        }
        public async Task<object> PostC()
        {
            var total = 0;
            var db = (_db as ITenant).GetConnection("0");
            var students = await db.Queryable<StudentModel>().Where(x => x.isDeleted == 0).ToPageListAsync(1, 50, total);
            db = (_db as ITenant).GetConnection("1");
            var otherstudents = await db.Queryable<StudentModel>().Where(x => x.isDeleted == 0).ToPageListAsync(1, 50, total);
            var sids = otherstudents.Select(x => x.Id).Distinct();

            var leftjoinResult = await _db.Queryable<StudentModel>()
            .LeftJoin<CourseModel>((o, cus) => o.CourseId == cus.Id)
            .Where(o => o.isDeleted == 0)
            .Select((o, cus) => new { Id = o.Id, CustomName = cus.CourseName })
            .ToPageListAsync(1, 50, total);
            return leftjoinResult;
        }

        [SugarTable("student")]
        public class StudentModel
        {
            [SugarColumn(IsPrimaryKey = true)]
            public int Id { get; set; }

            public string StudentName { get; set; }

            public int isDeleted { get; set; }

            public int CourseId { get; set; }
        }

        [SugarTable("course")]
        public class CourseModel
        {
            [SugarColumn(IsPrimaryKey = true)]
            public int Id { get; set; }

            public string CourseName { get; set; }

            public int isDeleted { get; set; }
        }
    } 
}