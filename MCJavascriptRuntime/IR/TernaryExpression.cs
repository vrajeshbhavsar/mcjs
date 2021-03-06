// --~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~--
// Copyright (c) [2010-2014] The Regents of the University of California
// All rights reserved.
// Redistribution and use in source and binary forms, with or without modification, are permitted (subject to the limitations in the disclaimer below) provided that the following conditions are met:
// * Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer.
// * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution.
// * Neither the name of The Regents of the University of California nor the project name nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission.
// NO EXPRESS OR IMPLIED LICENSES TO ANY PARTY'S PATENT RIGHTS ARE GRANTED BY THIS LICENSE. THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
// --~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~----~--~--~--~--
namespace mjr.IR
{
  public partial class TernaryExpression : Expression
  {
    public Expression Left { get; private set; }
    public Expression Middle { get; private set; }
    public Expression Right { get; private set; }

    public TernaryExpression()
    {
    }
    public TernaryExpression(Expression left, Expression middle, Expression right)
    {
      Left = left;
      Middle = middle;
      Right = right;
      SourceOffset = left.SourceOffset;

      Use(Left);
      Use(Middle);
      Use(Right);
    }

    public override string ToString()
    {
      return Left.ToString() + " ? " + Middle.ToString() + " : " + Right.ToString();
    }

    public override bool Replace(Node oldValue, Node newValue)
    {
      return
        Replace(Left, oldValue, newValue, n => Left = n)
        ||
        Replace(Middle, oldValue, newValue, n => Middle = n)
        ||
        Replace(Right, oldValue, newValue, n => Right = n)
        ||
        base.Replace(oldValue, newValue)
        ;
    }

    [System.Diagnostics.DebuggerStepThrough]
    public override void Accept(INodeVisitor visitor)
    {
      visitor.Visit(this);
    }
  }
}
