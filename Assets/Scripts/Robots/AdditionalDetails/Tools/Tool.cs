namespace Robot
{
    public class Tool : AdditionalDetail
    {
        protected bool _isPerformingAction;

        protected void InitializeTool()
        {
            _isPerformingAction = false;
        }
    }
}
