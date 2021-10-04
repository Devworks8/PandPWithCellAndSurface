using Microsoft.VisualStudio.TestTools.UnitTesting;
using Psim.Particles;
using Psim.ModelComponents;
using System;

namespace UnitTestPandPWithCellsandSurface
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddingPhonon()
        {
            Cell c = new Cell(100, 100);
            Phonon p1 = new Phonon(1);

            c.AddPhonon(p1);

            Assert.IsTrue(c.phonons.Count == 1);
            Assert.IsInstanceOfType(c.phonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void AddingIncPhonon()
        {
            Cell c = new Cell(100, 100);
            Phonon p1 = new Phonon(1);

            c.AddIncPhonon(p1);

            Assert.IsTrue(c.incomingPhonons.Count == 1);
            Assert.IsInstanceOfType(c.incomingPhonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void MergePhonon()
        {
            Cell c = new Cell(100, 100);
            Phonon p1 = new Phonon(1);

            c.AddIncPhonon(p1);
            c.MergeIncPhonons();

            Assert.IsTrue(c.phonons.Count == 1);
            Assert.IsTrue(c.incomingPhonons.Count == 0);
            Assert.IsInstanceOfType(c.phonons[0], typeof(Phonon));
        }

        [TestMethod]
        public void HandlingingPhonon()
        {
            Cell c = new Cell(100, 100);

            Phonon p1 = new Phonon(1);

            BoundarySurface bs = new BoundarySurface(SurfaceLocation.top, c);
            p1.SetDirection(1,1);
            _ = bs.HandlePhonon(p1);
            Assert.IsTrue(p1.Direction.DX == 1 && p1.Direction.DY == -1);

            bs = new BoundarySurface(SurfaceLocation.right, c);
            p1.SetDirection(1, 1);
            _ = bs.HandlePhonon(p1);
            Assert.IsTrue(p1.Direction.DX == -1 && p1.Direction.DY == 1);

            bs = new BoundarySurface(SurfaceLocation.bottom, c);
            p1.SetDirection(1, 1);
            _ = bs.HandlePhonon(p1);
            Assert.IsTrue(p1.Direction.DX == 1 && p1.Direction.DY == -1);

            bs = new BoundarySurface(SurfaceLocation.left, c);
            p1.SetDirection(1, 1);
            _ = bs.HandlePhonon(p1);
            Assert.IsTrue(p1.Direction.DX == -1 && p1.Direction.DY == 1);
        }

        [TestMethod]
        public void MoveToSurface()
        {
            Cell c = new Cell(100, 100);
            Phonon p1 = new Phonon(1);

            p1.SetCoords(40, 50);
            p1.SetDirection(1, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.top);

            p1.SetCoords(50, 40);
            p1.SetDirection(1, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.right);

            p1.SetCoords(40, 50);
            p1.SetDirection(-1, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.top);

            p1.SetCoords(50, 40);
            p1.SetDirection(-1, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.left);

            p1.SetCoords(40, 50);
            p1.SetDirection(1, -1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.bottom);

            p1.SetCoords(50, 40);
            p1.SetDirection(1, -1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.right);

            p1.SetCoords(90.85, 89.13);
            p1.SetDirection(-1, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.left);

            p1.SetCoords(90.85, 89.13);
            p1.SetDirection(0.0001, -1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.bottom);

            p1.SetCoords(50, 40);
            p1.SetDirection(0, 0);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == null);

            p1.SetCoords(50, 40);
            p1.SetDirection(1, 0);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.right);

            p1.SetCoords(50, 40);
            p1.SetDirection(-1, 0);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.left);

            p1.SetCoords(50, 40);
            p1.SetDirection(0, 1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.top);

            p1.SetCoords(50, 40);
            p1.SetDirection(0, -1);
            p1.Update(1, 10, Polarization.LA);
            p1.DriftTime = 10;
            Assert.IsTrue(c.MoveToNearestSurface(p1) == SurfaceLocation.bottom);
        }
    }
}
