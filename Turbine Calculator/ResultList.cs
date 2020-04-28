using BrightIdeasSoftware;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Turbine_Calculator {
    public class ResultList : IVirtualListDataSource {

        public readonly List<Result> list = new List<Result>();

        public void AddObjects(ICollection modelObjects) {
            if (modelObjects is ICollection<Result>) list.AddRange((ICollection<Result>)modelObjects);
        }

        public object GetNthObject(int n) {
            if (n >= list.Count) return null;
            return list[n];
        }

        public int GetObjectCount() {
            return list.Count;
        }

        public int GetObjectIndex(object model) {
            if (!(model is Result)) return -1;
            return list.IndexOf((Result)model);
        }

        public void InsertObjects(int index, ICollection modelObjects) {
            if (modelObjects is ICollection<Result>) list.InsertRange(index, (ICollection<Result>)modelObjects);
        }

        public void PrepareCache(int first, int last) {
            return;
        }

        public void RemoveObjects(ICollection modelObjects) {
            if (!(modelObjects is ICollection<Result>)) return;
            foreach (Result result in (ICollection<Result>)modelObjects) list.Remove(result);
        }

        public int SearchText(string value, int first, int last, OLVColumn column) {
            if (first >= list.Count || first < 0 || last >= list.Count || last < 0) return -1;
            if (column == TurbineCalculator.instance.bladeColumn) return list.FindIndex(x => x.blade == value);
            return 0;
        }

        public void SetObjects(IEnumerable collection) {
            if (collection is ICollection<Result>) {
                list.Clear();
                list.AddRange((ICollection<Result>)collection);
            }
        }

        public void Sort(OLVColumn column, SortOrder order) {
            if (column == TurbineCalculator.instance.bladeColumn) {
                if (order == SortOrder.Descending) list.OrderByDescending(x => x.blade);
                else list.OrderBy(x => x.blade);
            } else if (column == TurbineCalculator.instance.targetColumn) {
                if (order == SortOrder.Descending) list.OrderByDescending(x => x.target);
                else list.OrderBy(x => x.target);
            } else if (column == TurbineCalculator.instance.expansionColumn) {
                if (order == SortOrder.Descending) list.OrderByDescending(x => x.expansion);
                else list.OrderBy(x => x.expansion);
            } else if (column == TurbineCalculator.instance.posColumn) {
                if (order == SortOrder.Descending) list.OrderByDescending(x => x.position);
                else list.OrderBy(x => x.position);
            }
        }

        public void UpdateObject(int index, object modelObject) {
            if (index > list.Count || !(modelObject is Result)) return;
            list[index] = (Result)modelObject;
        }
    }

    public struct Result {
        public readonly int position;
        public readonly double target;
        public readonly double expansion;
        public readonly string blade;

        public Result(int position, double target, double expansion, string blade) {
            this.position = position;
            this.target = target;
            this.expansion = expansion;
            this.blade = blade;
        }
    }
}
