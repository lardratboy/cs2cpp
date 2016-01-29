﻿namespace Il2Native.Logic.DOM2
{
    using System;
    using System.Linq;

    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax.InternalSyntax;

    public class PostfixUnaryExpression : Expression
    {
        private Expression value;

        private SyntaxKind operatorKind;

        internal bool Parse(BoundSequence boundSequence)
        {
            base.Parse(boundSequence);
            var boundAssignmentOperator = boundSequence.SideEffects.Skip(boundSequence.SideEffects.Length - 1).First() as BoundAssignmentOperator;
            if (boundAssignmentOperator != null)
            {
                this.value = Deserialize(boundAssignmentOperator.Left) as Expression;
            }
            
            var postfixUnaryExpressionSyntax = boundSequence.Syntax.Green as PostfixUnaryExpressionSyntax;
            if (postfixUnaryExpressionSyntax != null)
            {
                this.operatorKind = postfixUnaryExpressionSyntax.OperatorToken.Kind;
            }

            var call = value as Call;
            if (call != null && (call.Method.Name == "op_Increment" || call.Method.Name == "op_Decrement"))
            {
                return false;
            }

            return true;
        }

        internal override void WriteTo(CCodeWriterBase c)
        {
            var call = value as Call;
            this.value.WriteTo(c);
            switch (this.operatorKind)
            {
                case SyntaxKind.PlusPlusToken:
                    c.TextSpan("++");
                    break;
                case SyntaxKind.MinusMinusToken:
                    c.TextSpan("--");
                    break;
            }
        }
    }
}
