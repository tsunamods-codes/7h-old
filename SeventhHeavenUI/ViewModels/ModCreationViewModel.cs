﻿using _7thHeaven.Code;
using _7thWrapperLib;
using Iros._7th;
using Iros._7th.Workshop;
using Iros.Mega;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeventhHeavenUI.ViewModels
{

    public class ModCreationViewModel : ViewModelBase
    {
        private string _nameInput;
        private string _idInput;
        private string _authorInput;
        private string _descriptionInput;
        private string _categoryInput;
        private List<string> _categoryList;
        private string _versionInput;
        private string _previewImageInput;
        private string _infoLinkInput;
        private string _releaseNotesInput;
        private List<string> _linkKindList;
        private string _linkKindInput;
        private string _sourceLinkInput;
        private string _modOutput;

        public string IDInput
        {
            get
            {
                return _idInput;
            }
            set
            {
                _idInput = value;
                NotifyPropertyChanged();
            }
        }

        public string NameInput
        {
            get
            {
                return _nameInput;
            }
            set
            {
                _nameInput = value;
                NotifyPropertyChanged();
            }
        }

        public string AuthorInput
        {
            get
            {
                return _authorInput;
            }
            set
            {
                _authorInput = value;
                NotifyPropertyChanged();
            }
        }

        public string DescriptionInput
        {
            get
            {
                return _descriptionInput;
            }
            set
            {
                _descriptionInput = value;
                NotifyPropertyChanged();
            }
        }

        public string CategoryInput
        {
            get
            {
                return _categoryInput;
            }
            set
            {
                _categoryInput = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> CategoryList
        {
            get
            {
                if (_categoryList == null)
                {
                    _categoryList = ModLoadOrder.Orders.Keys.OrderBy(s => s).ToList();
                }

                return _categoryList;
            }
        }

        public string VersionInput
        {
            get
            {
                return _versionInput;
            }
            set
            {
                _versionInput = value;
                NotifyPropertyChanged();
            }
        }

        public string PreviewImageInput
        {
            get
            {
                return _previewImageInput;
            }
            set
            {
                _previewImageInput = value;
                NotifyPropertyChanged();
            }
        }

        public string InfoLinkInput
        {
            get
            {
                return _infoLinkInput;
            }
            set
            {
                _infoLinkInput = value;
                NotifyPropertyChanged();
            }
        }

        public string ReleaseNotesInput
        {
            get
            {
                return _releaseNotesInput;
            }
            set
            {
                _releaseNotesInput = value;
                NotifyPropertyChanged();
            }
        }

        public List<string> LinkKindList
        {
            get
            {
                if (_linkKindList == null)
                {
                    _linkKindList = new List<string>()
                    {
                        LocationType.GDrive.ToString(),
                        LocationType.MegaSharedFolder.ToString(),
                        LocationType.Url.ToString(),
                    };
                }

                return _linkKindList;
            }
        }

        public string LinkKindInput
        {
            get
            {
                return _linkKindInput;
            }
            set
            {
                _linkKindInput = value;
                NotifyPropertyChanged();
            }
        }

        public string SourceLinkInput
        {
            get
            {
                return _sourceLinkInput;
            }
            set
            {
                _sourceLinkInput = value;
                NotifyPropertyChanged();
            }
        }

        public string ModOutput
        {
            get
            {
                return _modOutput;
            }
            set
            {
                _modOutput = value;
                NotifyPropertyChanged();
            }
        }


        public ModCreationViewModel()
        {
            IDInput = Guid.NewGuid().ToString();
            NameInput = "";
            CategoryInput = "Unknown";
            AuthorInput = "";
            DescriptionInput = "";
            VersionInput = "1.0";
            PreviewImageInput = "";
            InfoLinkInput = "";
            LinkKindInput = "GDrive";
            ReleaseNotesInput = "";
            SourceLinkInput = "";
        }

        public ModInfo GenerateModFromInput()
        {
            decimal.TryParse(VersionInput, out decimal parsedVersion);
            Guid.TryParse(IDInput, out Guid parsedId);

            ModInfo mod = new ModInfo()
            {
                ID = parsedId,
                Name = NameInput,
                Author = AuthorInput,
                Version = parsedVersion,
                Category = CategoryInput,
                Description = DescriptionInput,
                Link = InfoLinkInput,
                PreviewFile = PreviewImageInput,
                ReleaseDate = DateTime.Now,
                ReleaseNotes = ReleaseNotesInput
            };


            return mod;
        }

        public void GenerateModOutput()
        {
            ModOutput = Util.Serialize(GenerateModFromInput());
        }
    }
}