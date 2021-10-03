using Psim.Particles;
using Psim.Geometry2D;

namespace Psim.ModelComponents
{
	public interface ISurface
	{
		Cell HandlePhonon(Phonon p);
	}

	public class BoundarySurface : ISurface
	{
		public SurfaceLocation Location { get; }
		protected Cell cell;

		public BoundarySurface(SurfaceLocation location, Cell cell)
		{
			Location = location;
			this.cell = cell;
		}
		public virtual Cell HandlePhonon(Phonon p)
		{
			Vector direction = p.Direction;
			
			// Left/Right -> even ; Top/Bottom -> odd
			if((int)Location % 2 == 0)
            {
				p.SetDirection(-direction.DX, direction.DY);
            }
            else
            {
				p.SetDirection(direction.DX, -direction.DY);
			}

			return cell;
		}
	}
}
