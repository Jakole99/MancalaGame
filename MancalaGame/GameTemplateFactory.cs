using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class GameTemplateFactory
{

    public GameTemplate GetGameTemplate(Game.Variant gameVariant)
    {
        if (gameVariant == Game.Variant.Mancala)
            return (new MancalaTemplate());
        else if (gameVariant == Game.Variant.Wari)
            return (new WariTemplate());
        else if (gameVariant == Game.Variant.WarCali)
            return (new WarCaliTemplate());
        else
            return null;
    }

}