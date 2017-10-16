using System.Collections.Generic;

namespace Float.Models
{
    public abstract class BaseModel : IBaseModel
    {
        public abstract int ID { get; set; }
        public bool FullUpdate { get; set; }

        public abstract void ClearDirty();

        protected void SetProperty<T>(ref bool serialize, ref T oldValue, T newValue)
        {
            if (!EqualityComparer<T>.Default.Equals(oldValue, newValue))
                serialize = true;

            oldValue = newValue;
        }
    }

    public interface IBaseModel
    {
        int ID { get; set; }
        bool FullUpdate { get; set; }
        void ClearDirty();
    }
}
