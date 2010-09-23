using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pokemon.Core
{
    public class Camera2D
    {
        private bool _isMovingUsingScreenAxis;
        private Vector2 _position;
        private float _rotation;
        private float _zoom;

        public Camera2D()
        {
            _zoom = 1.0f;
            _rotation = 0.0f;
            _position = Vector2.Zero;
        }

        public Vector2 Position
        {
            set { _position = value; }
            get { return _position; }
        }

        public float Rotation
        {
            set { _rotation = value; }
            get { return _rotation; }
        }

        public float Zoom
        {
            set { _zoom = value; }
            get { return _zoom; }
        }

        public bool MoveUsingScreenAxis
        {
            set { _isMovingUsingScreenAxis = value; }
            get { return _isMovingUsingScreenAxis; }
        }

        public Matrix Transformation(Viewport viewport)
        {
            Matrix matrix = Matrix.CreateTranslation(new Vector3(-_position.X, -_position.Y, 0)) *
                            Matrix.CreateRotationZ(Rotation) *
                            Matrix.CreateScale(new Vector3(_zoom, _zoom, 0)) *
                            Matrix.CreateTranslation(new Vector3(viewport.Width * 0.5f, viewport.Height * 0.5f, 0));

            return matrix;
        }

        public void MoveRight(float distance)
        {
            if (distance != 0)
            {
                if (_isMovingUsingScreenAxis)
                {
                    _position.X += (float) Math.Cos(-_rotation) * distance;
                    _position.Y += (float) Math.Sin(-_rotation) * distance;
                }
                else
                    _position.X += distance;
            }
        }

        public void MoveLeft(float distance)
        {
            if (distance != 0)
            {
                if (_isMovingUsingScreenAxis)
                {
                    _position.X -= (float) Math.Cos(-_rotation) * distance;
                    _position.Y -= (float) Math.Sin(-_rotation) * distance;
                }
                else
                    _position.X += distance;
            }
        }

        public void MoveUp(float distance)
        {
            if (distance != 0)
            {
                if (_isMovingUsingScreenAxis)
                {
                    _position.X -= (float) Math.Sin(_rotation) * distance;
                    _position.Y -= (float) Math.Cos(_rotation) * distance;
                }
                else
                    _position.Y -= distance;
            }
        }

        public void MoveDown(float distance)
        {
            if (distance != 0)
            {
                if (_isMovingUsingScreenAxis)
                {
                    _position.X += (float) Math.Sin(_rotation) * distance;
                    _position.Y += (float) Math.Cos(_rotation) * distance;
                }
                else
                    _position.Y -= distance;
            }
        }
    }
}