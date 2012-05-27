// Copyright 2012, Ben Aston (ben@bj.ma).
// 
// This file is part of NViewModelFactory.
// 
// NViewModelFactory is free software: you can redistribute it and/or modify
// it under the terms of the GNU Lesser General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// NViewModelFactory is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU Lesser General Public License for more details.
// 
// You should have received a copy of the GNU Lesser General Public License
// along with NViewModelFactory. If not, see <http://www.gnu.org/licenses/>.

namespace Bjma.Utility.Web.ViewModelConstruction
{
	using System.Linq;
	using NBasicExtensionMethod;
	using NViewModelFactory;

	/// <summary>
	/// 	Responsible for encapsulating extension methods for the IViewModel interface.
	/// </summary>
	public static class IViewModelExtensions
	{
		/// <summary>
		/// 	Enumerates the properties on a view model marked with the TransientViewModelPropertyAttribute, and resets them to their default value.
		/// </summary>
		public static T ResetTransientProperties<T>(this T m) where T : IViewModel {
			//iterate over the properties marked as error markers and reset
			var propertiesToReset =
				typeof (T).GetFields().Where(
					f => f.GetCustomAttributes(typeof (TransientViewModelPropertyAttribute), true).Any());

			foreach (var p in propertiesToReset) {
				p.SetValue(m, p.FieldType.GetDefault());
			}

			return m;
		}
	}
}

// ReSharper restore InconsistentNaming