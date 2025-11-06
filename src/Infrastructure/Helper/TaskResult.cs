using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Infrastructure.Helper;

public class TaskResult
{
    public dynamic Result { get; set; }

    public IList<string> Errors { get; set; }

    public TaskResult()
    {
        Errors = new List<string>();
    }

    public bool Success
    {
        get
        {
            return Errors.Count == 0;
        }
    }

    public void AddError(string error)
    {
        this.Errors.Add(error);
    }

    public void AddErrors(TaskResult result)
    {
        foreach (string error in result.Errors)
        {
            this.AddError(error);
        }
    }

    public string ErrorsMessage()
    {
        return this.Errors.Aggregate("", (string current, string error) => current + error + "\n");
    }
}

