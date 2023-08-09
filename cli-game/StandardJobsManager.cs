public class StandardJobsManager
{
    private bool JobSet;

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
        }
    }


    public (Money, int) Work(int percentage)
    {
        int sleepyness;
        Money salaryOut;

        if(JobSet)
        {
            sleepyness = 100;
            salaryOut = jobsList[GetHiredIndex()].Salary;

            sleepyness = sleepyness / percentage * 100;
            salaryOut.giveMoney(salaryOut.getValueDeciaml() / (100 - percentage)*100);
        }
        else
        {
            sleepyness = 0;
            salaryOut = new Money(0);
        }
        
        return (salaryOut,sleepyness);
    }
}