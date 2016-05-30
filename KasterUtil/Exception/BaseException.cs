using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KasterUtil.Exception {
    /// <summary>
    /// Base class for all Auto Panel exceptions.
    /// </summary>
    public abstract class BaseException : System.Exception {
        /// <summary> Holder for the original exception. </summary>
        public System.Exception originalException { get; set; }
        public string message { get; set; }
        public string name { get; set; }
        public bool toDump { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public BaseException() {
            this.name = "Generic AutoPanel Exception";
            this.toDump = true;
        }

        /// <summary>
        /// Constructor taking representative name of the exception family
        /// </summary>
        /// <param name="name"></param>
        public BaseException(string name) {
            this.name = name;
            this.toDump = true;
        }

        /// <summary>
        /// Setter that initializes the oroginal exception data.
        /// </summary>
        /// <param name="e"></param>
        public BaseException set(System.Exception e) {
            return this.set(e, null, true);
        }

        /// <summary>
        /// Setter than initializes the custom message.
        /// </summary>
        /// <param name="message"></param>
        public BaseException set(string message) {
            return this.set(null, message, true);
        }

        /// <summary>
        /// Setter that initializes both the original exception and the custom message.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="message"></param>
        public BaseException set(System.Exception e, string message) {
            return this.set(e, message, true);
        }

        /// <summary>
        /// Setter that initailized the original exception and message, while also
        /// marking whether this particular excepton needs to be dumped or not.
        /// </summary>
        /// <param name="e"></param>
        /// <param name="message"></param>
        /// <param name="toDump"></param>
        /// <returns></returns>
        public BaseException set(System.Exception e, string message, bool toDump) {
            this.originalException = e;
            this.message = message;
            this.toDump = toDump;
            return this;
        }
    }

}
