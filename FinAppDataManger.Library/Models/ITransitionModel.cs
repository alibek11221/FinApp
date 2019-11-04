using System;

namespace FinAppDataManger.Library.Models
{
    public interface ITransitionModel
    {
        IArticleModel Article { get; set; }
        decimal Amount { get; set; }
        DateTime TransitionDate { get; set; }
    }
}