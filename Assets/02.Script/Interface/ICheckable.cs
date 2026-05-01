public interface ICheckable
{
    bool IsChecked { get; }

    void CheckCondition();
}
