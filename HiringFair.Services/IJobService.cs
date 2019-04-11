using HiringFair.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HiringFair.Services
{
    public interface IJobService
    {
        bool CreateJob(JobCreate model);

        IEnumerable<JobListItem> GetJobs();
        JobDetail GetJobById(int jobId);
        bool UpdateJob(JobEdit model);
        bool DeleteJob(int jobId);
    }
}
