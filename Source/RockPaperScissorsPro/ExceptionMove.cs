using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RockPaperScissorsPro
{
  internal class ExceptionMove : IllegalMove
  {
    readonly Exception _err;

    internal ExceptionMove(Exception err)
    {
      _err = err;
    }

    protected override bool CanBeatLegalMove(Move move)
    {
      return false;
    }

    public override string ToString()
    {
      return "EXCEPTION: " + _err;
    }
  }
}
