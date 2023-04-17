using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace AvaloniaCanvasTest
{
    internal class RectangleShape : BrExShape
    {
        protected override Geometry CreateDefiningGeometry()
        {
            mColumnRectangle = new Rect(0, 0,
                100, 100);

            return new RectangleGeometry(mColumnRectangle);
        }

        public override void Render(DrawingContext context)
        {
            base.Render(context);

            object? brush = null!;

            Application.Current?.TryFindResource("ControlBrush", out brush);

            context.DrawRectangle(
                (IBrush)brush!,
                null,
                mColumnRectangle);
        }

        Rect mColumnRectangle;
    }

    internal abstract class BrExShape : Control
    {
        internal Geometry? DefiningGeometry
        {
            get
            {
                if (mDefiningGeometry == null)
                {
                    mDefiningGeometry = CreateDefiningGeometry();
                }

                return mDefiningGeometry;
            }
        }

        protected abstract Geometry? CreateDefiningGeometry();

        protected void InvalidateGeometry()
        {
            mDefiningGeometry = null;

            InvalidateMeasure();
        }


        protected override Size MeasureOverride(Size availableSize)
        {
            if (DefiningGeometry is null)
            {
                return default;
            }

            return DefiningGeometry.Bounds.Size;
        }

        Geometry? mDefiningGeometry;
    }
}