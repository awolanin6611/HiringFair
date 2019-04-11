using HiringFair.Data;
using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public class JobService : IJobService
    {
        private readonly Guid _jobId;
        public JobService(Guid jobId)
        {
            _jobId = jobId;
        }
        public bool CreateJob(JobCreate model)
        {
            var entity = new Job
            {
                JobTitle = model.JobTitle,
                JobField = model.JobField,
                JobDescription = model.JobDescription,
            };
            using (var ctx = new ApplicationDbContext())
            {
                ctx.Jobs.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<JobListItem>
            GetJobs()
        {
            using (var ctx =  new ApplicationDbContext())
            {
                var query =
                    ctx
                    .Jobs
                    .Select(
                        e =>
                        new JobListItem
                        {
                            JobId = e.JobId,
                            JobTitle = e.JobTitle,
                            JobField = e.JobField,
                            JobDescription = e.JobDescription,
                        }
                        );
                return query.ToArray();
            }
        }

        public JobDetail GetJobById(int jobId)
        {
            using(var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Jobs
                    .Single(e => e.JobId == jobId);
                return
                    new JobDetail
                    {
                        JobId = entity.JobId,
                        JobTitle = entity.JobTitle,
                        JobField = entity.JobField,
                        JobDescription = entity.JobDescription,
                    };
            }
        }

        public bool UpdateJob(JobEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx
                    .Jobs
                    .Single(e => e.JobId == model.JobId);
                    entity.JobId = model.JobId;
                entity.JobTitle = model.JobTitle;
                entity.JobField = model.JobField;
                entity.JobDescription = model.JobDescription;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteJob(int jobId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                    .Jobs
                    .Single(e => e.JobId == jobId);

                ctx.Jobs.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }

    }
}
