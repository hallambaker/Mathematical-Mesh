﻿// This file is used by Code Analysis to maintain SuppressMessage
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given
// a specific target and scoped to a namespace, type, member, etc.

using System.Diagnostics.CodeAnalysis;

[assembly: SuppressMessage("Style", "IDE0060:Remove unused parameter",
      Justification = "Test code",
    Scope = "module")]
[assembly: SuppressMessage("Style", "IDE0059:Unnecessary assignment of a value",
      Justification = "Test code",
    Scope = "module")]


[assembly: SuppressMessage("Performance", "CA1822:Mark members as static",
      Justification = "Test code",
    Scope = "module")]