using System;
using System.Threading;
using System.Windows.Forms;

namespace DateControls
{
    public class DateTimePickerNullable : DateTimePicker
    {
        public delegate void GotFocusEventHandler(object sender, EventArgs e);
        public new event GotFocusEventHandler GotFocus;
        public delegate void LostFocusEventHandler(object sender, EventArgs e);
        public new event LostFocusEventHandler LostFocus;

        private DateTime? _value;
        private bool _noValueChange = false;

        public new DateTime? Value
        {
            get => _value;
            set
            {
                _value = value;
                if (_value == null)
                {
                    Format = DateTimePickerFormat.Custom;
                    CustomFormat = new string(' ', DateTime.Now.ToShortDateString().Length);
                    _noValueChange = true;
                    base.Value = DateTime.Now;
                    _noValueChange = false;
                }
                else
                {
                    Format = DateTimePickerFormat.Short;
                    _noValueChange = true;
                    base.Value = value.Value;
                    _noValueChange = false;
                }
            }
        }

        protected override void OnValueChanged(EventArgs eventArgs)
        {
            if (!_noValueChange)
            {
                Value = base.Value;
            }

            base.OnValueChanged(eventArgs);

        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Value = null;
            }

            if (Format == DateTimePickerFormat.Custom)
            {
                if (char.IsNumber((char)e.KeyCode))
                {

                    try
                    {
                        Value = Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern.ToLower().StartsWith("m") ?
                            new DateTime(DateTime.Now.Year, int.Parse(((char)e.KeyCode).ToString()), DateTime.Now.Day) :
                            new DateTime(DateTime.Now.Year, DateTime.Now.Month, int.Parse(((char)e.KeyCode).ToString()));

                        SendKeys.Send(((char)e.KeyCode).ToString());
                    }
                    catch (Exception)
                    {
                        // ignored
                    }

                    return;

                }
            }

            base.OnKeyDown(e);

        }

        private bool _hasFocus = false;

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (!_hasFocus)
            {
                _hasFocus = true;
                if (GotFocus != null)
                    GotFocus(this, new EventArgs());
            }
        }

        protected override void OnValidated(EventArgs e)
        {
            base.OnValidated(e);
            _hasFocus = false;

            if (LostFocus != null)
            {
                LostFocus(this, new EventArgs());
            }
        }
    }

}
