/*
Copyright (c) 2013, Dienst Wegverkeer, RDW, All rights reserved. 

Redistribution and use in source and binary forms, with or without modification, are permitted provided that the following conditions are met: 

• Redistributions of source code must retain the above copyright notice, this list of conditions and the following disclaimer. 
• Redistributions in binary form must reproduce the above copyright notice, this list of conditions and the following disclaimer in the documentation and/or other materials provided with the distribution. 
• Neither the name of the Dienst Wegverkeer, RDW,  nor the names of its contributors may be used to endorse or promote products derived from this software without specific prior written permission. 

THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.

*/

// <auto-generated />
namespace EVR.Reader
{
    using System.Security.Cryptography.X509Certificates;

    public class RegistrationB : Registration
    {
        #region RegistrationB_Properties
        /// <summary>
        /// J Voertuigcategorie
        /// </summary>
        public string J { get; private set; }

        /// <summary>
        /// R Kleur
        /// </summary>
        public string R { get; private set; }

        /// <summary>
        /// V.9 Milieuklasse EG-goedkeuring
        /// </summary>
        public string V9 { get; private set; }

        /// <summary>
        /// F.2 Toegstane max.massa
        /// </summary>
        public string F2 { get; private set; }

        /// <summary>
        /// F.3 Toegestane max.massa comb.
        /// </summary>
        public string F3 { get; private set; }

        /// <summary>
        /// T Max. snelheid
        /// </summary>
        public string T { get; private set; }

        /// <summary>
        /// Q.1 Tech max.massa AHW (geremd)
        /// </summary>
        public string O1 { get; private set; }

        /// <summary>
        /// Q.2 Tech max.massa AHW (ongeremd)
        /// </summary>
        public string O2 { get; private set; }
        #endregion

        public override void CreateSignature()
        {
            this.Signature = EFSignature.Create_Signature_B(this.AID, this.cardReader);
        }

        public override void CreateDocumentSigner()
        {
            EFCIA_DS ds = EFCIA_DS.Create_DS_B(eVRCardReader.eVRCApplicatie, cardReader);

            this.DS = new X509Certificate2(ds.Value);
        }

        public override System.Text.Encoding CharacterSetEncoding
        {
            get;
            set;
        }

        public RegistrationB(EFSOd EFSOd, X509Certificate2 CSCA, byte[] AID, CardReader cardReader, System.Text.Encoding encoding)
            : base(EFSOd, CSCA, AID, cardReader, new byte[] { 0xD0, 0x11 })
        {
            this.CharacterSetEncoding = encoding;
            this.J = this.DecodeString("1,72|1,98");            // voertuigCategorie
            this.R = this.DecodeString("1,72|1,9F24");          // kleur
            this.V9 = this.DecodeString("1,72|1,B0|1,9F31");    // milKlasse
            this.F2 = this.DecodeString("1,72|1,A4|1,96");      // toegMaxMassa
            this.F3 = this.DecodeString("1,72|1,A4|1,97");      // toegMaxMassaComb
            this.T = this.DecodeString("1,72|1,9F25");          // maxSnelheid
            this.O1 = this.DecodeString("1,72|1,AE|1,9B");      // trailerBreaked
            this.O2 = this.DecodeString("1,72|1,AE|1,9C");      // trailerUnBreaked
        }
    }
}
