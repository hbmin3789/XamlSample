using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomControls.Common
{
    /// <summary>
    /// 일반 모델을 트리에 바인딩 할 수 있게 만듬
    /// </summary>
    public class Treeable : BindableBase
    {
        protected ObservableCollection<Treeable> _childItems = new ObservableCollection<Treeable>();
        public virtual ObservableCollection<Treeable> ChildItems
        {
            get => _childItems;
            set => SetProperty(ref _childItems, value);
        }
    }
}
