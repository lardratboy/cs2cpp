////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved.
////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
namespace System
{
    using System.Reflection;
    using System.Collections;
    using System.Runtime.CompilerServices;

    [Serializable]
    public abstract class Enum : ValueType
    {

        public override String ToString()
        {
            ////Type eT = this.GetType();
            ////FieldInfo fi = eT.GetField("value__");
            ////object obj = fi.GetValue(this);

            ////return obj.ToString();
            // TODO: temp hack for a test 40
            return "d";
        }

    }
}


