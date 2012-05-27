﻿// Copyright 2012, Ben Aston (ben@bj.ma).
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

namespace NViewModelFactory
{
	/// <summary>
	/// 	Enables use of a strongly typed dto to pass arguments into the CreateModel method.
	/// </summary>
	public interface IViewModelFactory<out TModel, in TCreationDto>
		where TModel : IServiceLocatorInstantiatedViewModel, new()
	{
		TModel CreateModel(TCreationDto dto = default(TCreationDto));
	}
}