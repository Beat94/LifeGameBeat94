public class StandardJobsManager
{
    public bool JobSet{get;set;}

    public StandardJobsManager()
    {
        this.JobSet = false;
    }

    private List<StandardJobs> jobsList = new List<StandardJobs>()
        {
            new StandardJobs("Mechanic", new Money(4000000)),
            new StandardJobs("Florist", new Money(3500000))
        };

    private int GetHiredIndex()
    {
        int outIndex = 999999;

        for(int i = 0; i < jobsList.Count; i++)
        {
            if(jobsList[i].Hired)
            {
                outIndex = i;
            }
        }

        return outIndex;
    }

    public List<(string,string)> GetJobList()
    {
        List<(string,string)> JobListOut = new();

        for(int i = 0; i < jobsList.Count; i++)
        {
            JobListOut.Add((jobsList[i].Name,i.ToString()));
        }

        return JobListOut;
    }

    public void GetJob(int index)
    {
        if(JobSet == false)
        {
            jobsList[index].Hired = true;
            JobSet = true;
        }
    }

    public void LeaveJob()
    {
        if(JobSet == true)
        {
            jobsList[GetHiredIndex()].Hired = false;
            JobSet = false;
        }
    }


    public (Money, int) Work(int percentage)
    {
        int sleepyness;
        Money salary;
        Money salaryOut;

        if(JobSet)
        {
            salary = jobsList[GetHiredIndex()].Salary;

            sleepyness = percentage;
            salaryOut = new Money(salary.getValueDecimal() / 30 / 100 * percentage);
        }
        else
        {
            sleepyness = 0;
            salaryOut = new Money(0);
        }
        
        return (salaryOut,sleepyness);
    }

    public string getJobToString(int index) => jobsList[index].Name;

    public string GetJobHired()
    {
        string job = "unemployed";

        if(JobSet)
        {
            job = getJobToString(GetHiredIndex());
        }

        return job;
    }
}