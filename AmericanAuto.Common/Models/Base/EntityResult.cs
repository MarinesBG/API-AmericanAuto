namespace AmericanAuto.Common.Models.Base
{
    public class EntityResult<TModel>
    {
        public EntityResult(TModel entity)
        {
            Success = true;
            Entity = entity;
        }

        public EntityResult(string error)
        {
            Success = false;
            Error = error;
        }

        public bool Success { get; set; }

        public string Error { get; set; }

        public TModel Entity { get; set; }
    }
}
