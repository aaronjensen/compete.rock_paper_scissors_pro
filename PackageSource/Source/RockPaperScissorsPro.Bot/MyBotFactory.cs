using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Compete.Bot;

namespace RockPaperScissorsPro.Bot
{
  public class MyBotFactory : IBotFactory
  {
    public IBot CreateBot()
    {
      return new MyBot();
    }
  }
}
