using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Configuration.Assemblies;
using System.Xml;

namespace Monogame_1___5_Summative
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D kogasaTexture, kogasa1Texture, kogasa2Texture, kogasa3Texture, kogasa4Texture, kogasa5Texture, booTexture, topTexture, riseTexture, lickTexture, warnTexture, endTexture;
        Rectangle kogasaRect, kogasa1Rect, kogasa2Rect, kogasa3Rect, kogasa4Rect, kogasa5Rect, booRect, topRect, riseRect, lickRect, warnRect, endRect;
        float seconds, startTime, introTime, totalTime;
        SoundEffectInstance ah, halloween, pipe, powerup;
        bool jumpscare, spooky, shrink, growth = false;
        MouseState mouseState;
        enum Screen
        {
            Intro,
            Spook,
            End
        }
        Screen screen;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            _graphics.PreferredBackBufferWidth = 830;
            _graphics.PreferredBackBufferHeight = 950;
            _graphics.ApplyChanges();
            jumpscare = false;
            spooky = false;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            screen = Screen.Intro;
            kogasaRect = new Rectangle(0, -30, 830, 1001);
            kogasa1Rect = new Rectangle(0, 96, 830, 875);
            kogasa2Rect = new Rectangle(0, 221, 830, 750);
            kogasa3Rect = new Rectangle(0, 471, 830, 500);
            kogasa4Rect = new Rectangle(0, 691, 830, 250);
            kogasa5Rect = new Rectangle(0, 841, 830, 100);
            booRect = new Rectangle(0, -30, 830, 1001);
            topRect = new Rectangle(0, -30, 830, 1001);
            riseRect = new Rectangle(0, -30, 830, 1001);
            lickRect = new Rectangle(0, -30, 830, 1001);
            warnRect = new Rectangle(0, -30, 830, 1001);
            endRect = new Rectangle(0, -30, 830, 1001);
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            kogasaTexture = Content.Load<Texture2D>("kogasa");
            kogasa1Texture = Content.Load<Texture2D>("kogasa1");
            kogasa2Texture = Content.Load<Texture2D>("kogasa2");
            kogasa3Texture = Content.Load<Texture2D>("kogasa3");
            kogasa4Texture = Content.Load<Texture2D>("kogasa4");
            kogasa5Texture = Content.Load<Texture2D>("kogasa5");
            booTexture = Content.Load<Texture2D>("boo!");
            topTexture = Content.Load<Texture2D>("top");
            riseTexture = Content.Load<Texture2D>("rise");
            lickTexture = Content.Load<Texture2D>("lick");
            warnTexture = Content.Load<Texture2D>("warn");
            endTexture = Content.Load<Texture2D>("gay");
            ah = Content.Load<SoundEffect>("ah").CreateInstance();
            halloween = Content.Load<SoundEffect>("halloween").CreateInstance();
            pipe = Content.Load<SoundEffect>("pipe").CreateInstance();
            powerup = Content.Load<SoundEffect>("powerup").CreateInstance();
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            seconds = (float)gameTime.TotalGameTime.TotalSeconds;
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
            // TODO: Add your update logic here
            if (screen == Screen.Intro)
            {
                if (seconds > 4)
                {
                    screen = Screen.Spook;
                    halloween.Play();
                }

                else if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    introTime = startTime;
                    screen = Screen.Spook;
                    halloween.Play();
                }
            }



            else if (screen == Screen.Spook)
            {


                totalTime = seconds - introTime;

                //if (seconds > 10)
                // {
                //seconds = (float)gameTime.TotalGameTime.TotalSeconds;
                //}

                if (seconds > 6.9) 
                { 
                    pipe.Play();
                    shrink = true;
                }

                if (seconds > 7 && spooky)
                {
                    halloween.Stop();
                    spooky = true;
                }

                if (seconds > 7.9)
                {
                    pipe.Stop();
                    shrink = true;
                }

                if (totalTime > 10.5 && !jumpscare)
                {
                    ah.Play();
                    jumpscare = true;
                }

                if (seconds > 13.5 && !jumpscare)
                {
                    powerup.Play();
                    growth = true;
                }

                if (totalTime > 15)
                {
                    screen = Screen.End;

                }

            }

            


            mouseState = Mouse.GetState();
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.PaleVioletRed);
            _spriteBatch.Begin();

            if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(warnTexture, new Rectangle(0, -50, 830, 1001), Color.White);
            }

            else if (screen == Screen.Spook)
            {

                _spriteBatch.Draw(kogasaTexture, kogasaRect, Color.White);

                

                if (totalTime > 7)
                {
                    _spriteBatch.Draw(kogasa1Texture, kogasa1Rect, Color.White);
                    kogasaRect.Height = 0;
                    kogasaRect.Width = 0;
                }

                if (totalTime > 7.05)
                {
                    _spriteBatch.Draw(kogasa2Texture, kogasa2Rect, Color.White);
                    kogasa1Rect.Height = 0;
                    kogasa1Rect.Width = 0;
                }

                if (totalTime > 7.1)
                {
                    _spriteBatch.Draw(kogasa3Texture, kogasa3Rect, Color.White);
                    kogasa2Rect.Height = 0;
                    kogasa2Rect.Width = 0;
                }

                if (totalTime > 7.15)
                {
                    _spriteBatch.Draw(kogasa4Texture, kogasa4Rect, Color.White);
                    kogasa3Rect.Height = 0;
                    kogasa3Rect.Width = 0;
                }

                if (totalTime > 7.2)
                {
                    _spriteBatch.Draw(kogasa5Texture, kogasa5Rect, Color.White);
                    kogasa4Rect.Height = 0;
                    kogasa4Rect.Width = 0;
                }


                if (totalTime > 7.3)
                {
                    kogasa5Rect.Height = 0;
                    kogasa5Rect.Width = 0;
                }


                if (totalTime > 10.7)
                {
                    _spriteBatch.Draw(topTexture, topRect, Color.White);
                }

                if (totalTime > 10.8)
                {
                    _spriteBatch.Draw(riseTexture, riseRect, Color.White);
                    topRect.Height = 0;
                    topRect.Width = 0;
                }

                if (totalTime > 10.9)
                {
                    _spriteBatch.Draw(lickTexture, lickRect, Color.White);
                    riseRect.Height = 0;
                    riseRect.Width = 0;
                }

                if (totalTime > 11)
                {
                    _spriteBatch.Draw(booTexture, booRect, Color.White);
                    lickRect.Height = 0;
                    lickRect.Width = 0;
                }

                if (totalTime > 14)
                {

                    booRect.Height = 0;
                    booRect.Width = 0;
                    lickRect.Height = 1001;
                    lickRect.Width = 830;
                }

                if (totalTime > 14.1)
                {

                    lickRect.Height = 0;
                    lickRect.Width = 0;
                    riseRect.Height = 1001;
                    riseRect.Width = 830;
                }
                if (totalTime > 14.2)
                {

                    riseRect.Height = 0;
                    riseRect.Width = 0;
                    topRect.Height = 1001;
                    topRect.Width = 830;
                }
                if (totalTime > 14.3)
                {

                    topRect.Height = 0;
                    topRect.Width = 0;
                    kogasa5Rect.Height = 100;
                    kogasa5Rect.Width = 830;
                }

                if (totalTime > 14.4)
                {

                    kogasa5Rect.Height = 0;
                    kogasa5Rect.Width = 0;
                    kogasa4Rect.Height = 250;
                    kogasa4Rect.Width = 830;
                }

                if (totalTime > 14.5)
                {

                    kogasa4Rect.Height = 0;
                    kogasa4Rect.Width = 0;
                    kogasa3Rect.Height = 500;
                    kogasa3Rect.Width = 830;
                }

                if (totalTime > 14.6)
                {

                    kogasa3Rect.Height = 0;
                    kogasa3Rect.Width = 0;
                    kogasa2Rect.Height = 750;
                    kogasa2Rect.Width = 830;
                }

                if (totalTime > 14.7)
                {

                    kogasa2Rect.Height = 0;
                    kogasa2Rect.Width = 0;
                    kogasa1Rect.Height = 875;
                    kogasa1Rect.Width = 830;
                }
                if (totalTime > 14.8)
                {

                    kogasa1Rect.Height = 0;
                    kogasa1Rect.Width = 0;
                    kogasaRect.Height = 1500;
                    kogasaRect.Width = 830;
                }

                if (totalTime > 14.9)
                {

                    kogasa1Rect.Height = 0;
                    kogasa1Rect.Width = 0;
                    kogasaRect.Height = 1001;
                    kogasaRect.Width = 830;
                }


            }
            else if (screen == Screen.End)
            {
                _spriteBatch.Draw(endTexture, endRect, Color.White);
            }
            _spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}