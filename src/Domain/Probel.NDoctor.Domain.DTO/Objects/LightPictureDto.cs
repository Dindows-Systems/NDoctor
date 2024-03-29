﻿/*
    This file is part of NDoctor.

    NDoctor is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    NDoctor is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with NDoctor.  If not, see <http://www.gnu.org/licenses/>.
*/
namespace Probel.NDoctor.Domain.DTO.Objects
{
    /// <summary>
    /// Represents the thumbnail of a picture
    /// </summary>
    public class LightPictureDto : BaseDto
    {
        #region Fields

        private TagDto tag;
        private byte[] thumbnailedBitmap;

        #endregion Fields

        #region Properties

        /// <summary>
        /// Gets or sets the tag to categorise this picture.
        /// </summary>
        /// <value>
        /// The tag.
        /// </value>
        public TagDto Tag
        {
            get { return this.tag; }
            set
            {
                this.tag = value;
                this.OnPropertyChanged(() => this.Tag);
            }
        }

        /// <summary>
        /// Gets or sets the thumbnail of the picture.
        /// </summary>
        /// <value>
        /// The thumbnail bitmap.
        /// </value>
        public byte[] ThumbnailBitmap
        {
            get { return this.thumbnailedBitmap; }
            set
            {
                this.thumbnailedBitmap = value;
                this.OnPropertyChanged(() => ThumbnailBitmap);
            }
        }

        #endregion Properties
    }
}