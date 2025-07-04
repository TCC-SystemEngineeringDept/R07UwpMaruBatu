using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UwpMaruBatu
{
    internal class CheckClass1
    {
        /// <summary>
        /// 5x5の配列と、行・列を指定し、そこに配置することができればtrue、できなければfalseを返す。
        /// 行と列は１～５を渡される。配列bANの最初の要素（[0,0]）は、行１・列１となる。
        /// 
        /// 置けるかどうかの判断は、そこに〇または×が入っていれば配置できないと考える。
        /// 配列の要素は、「0:空白, 1:〇, 2:×」とする。それ以外が入ることはない。
        /// </summary>
        /// <param name="bAN">5*5の配列</param>
        /// <param name="row">行(1～5)</param>
        /// <param name="col">列(1～5)</param>
        /// <returns></returns>
        internal static bool CanPlaceMark(int[,] bAN, int row, int col)
        {
            int masu = bAN[row,col];
            if(masu == 0) return false;
            return true;
        }
    }
}
