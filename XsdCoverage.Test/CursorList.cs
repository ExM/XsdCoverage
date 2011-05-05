using System;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;

namespace XsdCoverage
{
	public class CursorList<T>: IList<T> where T : ICursor<XElement>
	{
		private ICursor<XElement> _cursor;
		private XName _childsName;

		public CursorList(ICursor<XElement> cursor, XName childsName)
		{
			_cursor = cursor;
			_childsName = childsName;
		}

		public T this[int index]
		{
			get
			{
				if (index < 1)
					throw new IndexOutOfRangeException("allowed only a value greater than or equal to 1");

				IEnumerable<XElement> childs = _cursor.Target.Elements(_childsName);
				XElement target = childs.Skip(index - 1).FirstOrDefault();

				if (target == null)
				{
					int curCount = childs.Count();
					if(!_cursor.Build)
						throw new IndexOutOfRangeException(string.Format("in `{0}' expected {1} elements of `{2}', but was {3}",
							_cursor.Target.GetAbsoluteXPath(), index, _childsName, curCount));
					int toAdd = index - curCount;
					for(int i = 0; i< toAdd; i++)
					{
						target = new XElement(_childsName);
						_cursor.Target.Add(target);
					}
				}

				return CreateItem(target);
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public void Insert(int index, T item)
		{
			//TODO: Insert
			throw new NotImplementedException();
		}

		public void RemoveAt(int index)
		{
			//TODO: RemoveAt
			throw new NotImplementedException();
		}

		public void Add(T item)
		{
			//TODO: Add
			throw new NotImplementedException();
		}

		public void Clear()
		{
			foreach (XElement el in _cursor.Target.Elements(_childsName).ToList())
				el.Remove();
		}

		public int Count
		{
			get
			{
				return _cursor.Target.Elements(_childsName).Count();
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			return _cursor.Target.Elements(_childsName).Select(CreateItem).GetEnumerator();
		}

		private T CreateItem(XElement target)
		{
			if (target == null)
				throw new InvalidOperationException("elements have been removed");
			T result = CursorCreater<T, XElement>.Create(_cursor, target);
			result.Build = _cursor.Build;
			return result;
		}

		#region not implemented

		public int IndexOf(T item)
		{
			throw new NotImplementedException();
		}

		public bool Contains(T item)
		{
			throw new NotImplementedException();
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			throw new NotImplementedException();
		}

		public bool IsReadOnly
		{
			get { throw new NotImplementedException(); }
		}

		public bool Remove(T item)
		{
			throw new NotImplementedException();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			throw new NotImplementedException();
		}
		#endregion
	}
}
