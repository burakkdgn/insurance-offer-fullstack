import React, { useState } from 'react';
import Button from '@mui/material/Button';
import Modal from '@mui/material/Modal';
import Box from '@mui/material/Box';
import Typography from '@mui/material/Typography';
import { useFormik } from "formik";
import axiosInstance from "../utils/axiosInstance";

const style = {
    position: 'absolute',
    top: '50%',
    left: '50%',
    transform: 'translate(-50%, -50%)',
    width: 1500,
    bgcolor: 'background.paper',
    border: '2px solid #273a7e',
    borderRadius: 2,
    boxShadow: 24,
    p: 4,
};

const PersonalInformations = ({ nextStep }) => {
    const [selectedOption, setSelectedOption] = useState('Kendim için');
    const [open, setOpen] = useState(false);
    const [modalContent, setModalContent] = useState({
        title: '',
        content: ''
    });


 const savePersonalInformation = async (formData) => {
        try {
          const response = await axiosInstance.post('/Applicants/add', formData);
          console.log('Kullanıcı başarıyla kaydedildi:', response.data);
          return response.data;
        } catch (error) {
          console.error('Kullanıcı kaydedilemedi:', error);
          throw error;
        }
      };
      const formik = useFormik({
        initialValues: {
          tck: '',
          birthDate: '',
          email: '',
          phoneNumber: '',
        },
        onSubmit: async (values) => {
          try {
            const response = await savePersonalInformation(values);
            console.log('Response:', response);
            nextStep(); // Bir sonraki adıma geçiş
          } catch (error) {
            alert('Bilgiler kaydedilemedi, lütfen tekrar deneyin.');
          }
        },
      });
      <form onSubmit={formik.handleSubmit}>
      <label>T.C. Kimlik Numaranız (11 Hane)</label>
      <input
        type="text"
        name="tck"
        placeholder="T.C. Kimlik Numaranız"
        maxLength="11"
        value={formik.values.tck}
        onChange={formik.handleChange}
      />
    
      <label>Doğum Tarihiniz</label>
      <input
        type="date"
        name="birthDate"
        value={formik.values.birthDate}
        onChange={formik.handleChange}
      />
    
      <label>E-posta Adresiniz</label>
      <input
        type="email"
        name="email"
        placeholder="E-posta Adresiniz"
        value={formik.values.email}
        onChange={formik.handleChange}
      />
    
      <label>Cep Telefonu Numaranız</label>
      <input
        type="text"
        name="phoneNumber"
        placeholder="5xx-xxx-xxxx"
        maxLength="10"
        value={formik.values.phoneNumber}
        onChange={formik.handleChange}
      />
    
      <button type="submit">Kaydet ve Devam Et</button>
    </form>
          



    // Modal içerikleri
    const modalContents = {
        kvkk: {
            title: 'Eureko Sigorta KVKK Aydınlatma Metni',
            content: `İNTERNET SİTESİ KULLANIMI İÇİN KİŞİSEL VERİLERİN İŞLENMESİ HAKKINDA AYDINLATMA METNİ
İşbu KVK Aydınlatma Metni ( "Aydınlatma Metni"), Eureko Sigorta A.Ş. ( "Şirketimiz"; "Eureko") olarak, resmi internet sitemiz olan https://www.eurekosigorta.com.tr adresini ( "Site") ve/veya Eureko Sigorta Mobil uygulamasını (“Mobil Uygulama”) ziyaret ettiğinizde, sigorta poliçesine yönelik başvuru ve teklif talebi işlemlerinizde geçerli olmak üzere ve veri sorumlusu sıfatıyla KVK mevzuatından kaynaklanan aydınlatma yükümlülüğümüzün yerine getirilmesi amacıyla hazırlanmıştır.
Eureko olarak, kişisel verilerinizin 6698 sayılı Kişisel Verilerin Korunması Kanunu ( "KVKK") ve ikincil düzenlemelerine (birlikte "KVK mevzuatı") uygun olarak işlenmesi ve korunması için azami hassasiyeti göstermekteyiz.
1. İşlenen Kişisel Verileriniz, İşlenme Amaçları ve Hukuki Sebebi:
Kişisel Verileriniz (kimlik, iletişim, işlem güvenliği, müşteri işlem, poliçe ve varsa poliçede mevcut acente bilgileri) www.eurekosigorta.com.tr adresimizden yapacağınız poliçeye yönelik başvuru ve teklif taleplerinizde aşağıdaki amaç ve şartlar doğrultusunda işlenebilecektir.
- Sigorta sözleşmesi tanzim etmek üzere risk değerlendirmesi yapılabilmesi, tazminatlarının hesaplanması ve ödenmesi süreçlerinin yürütülmesi, poliçe prim ve teminatlarının belirlenebilmesi, sigorta teklifi oluşturulması amacıyla işlenen kişisel veriler, Kanun’un 5’inci maddesinin 2’nci fıkrasının (c) bendi uyarınca sigorta sözleşmesinin kurulması ve ifasıyla doğrudan doğruya ilgili olması kaydıyla, sözleşmenin taraflarına ait kişisel verilerin işlenmesinin gerekli olması şartına dayalı olarak;
-5651 Sayılı İnternet Ortamında Yapılan Yayınların Düzenlenmesi Ve Bu Yayınlar Yoluyla İşlenen Suçlarla Mücadele Edilmesi Hakkında Kanun Ve İkincil Düzenlemelerinden Doğan Yükümlülüklerimizi Yerine Getirilmesi amacı ile, 5’inci maddesinin 2’nci fıkrasının (ç) bendi uyarınca veri sorumlusunun hukuki yükümlülüğünü yerine getirebilmesi için zorunlu olması şartına dayalı olarak,
- Kanunlar ve ilgili mevzuatlardan kaynaklanan bilgi/belge saklama yükümlülüklerinin ifası ve işlemlerin kayıt altına alınması amacıyla işlenen kişisel veriler, Kanun’un 5’inci maddesinin 2’nci fıkrasının (ç) bendi uyarınca veri sorumlusunun hukuki yükümlülüğünü yerine getirebilmesi için veri işlemenin zorunlu olması şartına dayalı olarak;
- Müşteri ile acente etkileşimlerinin sağlanabilmesi ve veri analizi çalışmaları amacıyla işlenen kişisel veriler, Kanun’un 5’inci maddesinin 2’nci fıkrasının (f) bendi uyarınca; ilgili kişinin temel hak ve özgürlüklerine zarar vermemek kaydıyla, veri sorumlusunun meşru menfaatleri için veri işlenmesinin zorunlu olması şartına dayalı olarak; işlenebilecektir.
- Ürün Ve Hizmetlerimize İlişkin Talep, Şikâyet, Soru Ve Önerilerinizi Değerlendirerek Sizlere Geri Dönüş/Destek Sağlanması amacı ile işlenen kişisel veriler, Kanun’un 5’inci maddesinin 2’nci fıkrasının (e) bendi uyarınca bir hakkın tesisi, kullanılması veya korunması için veri işlemenin zorunlu olması şartına dayalı olarak; işlenebilecektir.
Eureko tarafından sunulan hizmetlere yönelik işlenen kişisel verilere ilişkin detaylı tablo aydınlatma metnine buradan ulaşabilirsiniz.
2. Kişisel Verilerinizin Toplanma Yöntemi 
Kişisel verileriniz; Eureko Sigorta internet sitesinin kullanımı sırasında gerçekleştirdiğiniz işlemlerden, ürün/teklif işlemleri, çevrimiçi işlemler, hasar bildirimi, bize ulaşın alanlarında ilettiğiniz bilgiler vasıtasıyla elektronik ortamda, tamamen veya kısmen otomatik olan ya da herhangi bir veri kayıt sisteminin parçası olarak otomatik olmayan yollarla temin edilerek, işlenmekte ve güncellenmektedir.
3. Kişisel Verilerinizin Aktarıldığı Taraflar ve Aktarım Amaçları
Eureko tarafından, kişisel verilerinizi işleme amaçlarıyla bağlantılı, sınırlı ve ölçülü olmak kaydıyla ve ilk maddede anılan hukuki sebeplere dayalı olarak yurt içi tedarikçiler (aktüerler, eksperler, asistans hizmet şirketleri, bilgi teknoloji hizmet sağlayıcıları, arşiv hizmeti firmaları, danışmanlar vb), iş ortakları (reasürörler, acente vb), yetkili kurum kuruluşlar (Hazine ve Maliye Bakanlığı, Sigorta Bilgi ve Gözetim Merkezi (SBM), Bilgi Teknolojileri Kurumu (BTK) vb.) ve diğer 3. kişilere (diğer sigorta şirketleri, sigorta ettiren kişi/kurum vb) mevzuatın izin verdiği ve gerektiği ölçü ve koşullarda aktarılmaktadır.
4. Bilgi Edinme Hakkınız
KVK Kanunu’nun 11. maddesi kapsamında, Şirketimize başvurarak kişisel verilerinizin; 
(i) işlenip işlenmediğini öğrenme; 
(ii) işlenmişse buna ilişkin bilgi talep etme, işlenme amacını ve amacına uygun kullanılıp kullanılmadığını öğrenme,
(iii) yurt içinde / yurt dışında aktarıldığı 3. kişileri bilme, eksik / yanlış işlenmişse düzeltilmesini isteme; 
(iv) KVK Kanunu’nun 7. maddesinde öngörülen şartlar çerçevesinde silinmesini / yok edilmesini isteme; (v) kişisel verilerinizin KVK Kanunu’nun 7. maddesi kapsamında silinmesi ve yok edilmesi ve eksik / yanlış işlenmiş kişisel verilerinin düzeltilmesi taleplerinin, kişisel verilerin aktarıldığı üçüncü kişilere bildirilmesini isteme; 
(vi) münhasıran otomatik sistemler ile analiz edilmesi nedeniyle aleyhinize bir sonucun ortaya çıkmasına itiraz etme, (vii) kanuna aykırı olarak işlenmesi sebebiyle zarara uğramanız hâlinde zararın giderilmesini talep etme haklarına sahip olduğunuzu bildiririz.

Yukarıda belirtilen haklarınızdan yararlanmak için başvurularınızı Altunizade Mahallesi Ord. Prof. Fahrettin Kerim Gökay Cad. No:20 34662 Üsküdar / İstanbul adresinden, kayıtlı elektronik posta (KEP) adresimiz eurekosigorta@hs03.kep.tr veya https://www.eurekosigorta.com.tr/iletisim/bize-yazin üzerinden yazılı olarak veya +90 (216) 400 10 00 numaralı telefondan Eureko’ya iletebilirsiniz.`
        },
        sozlesme: {
            title: 'Eureko Sigorta Kullanıcı Sözleşmesi',
            content: `Eureko Sigorta’nın şimdi ilettiğim ve/veya gelecekte ileteceğim kimlik ve iletişim bilgilerimi reklam, kampanya ve benzeri pazarlama faaliyetlerin yürütülmesi amacıyla elektronik ortamlarda otomatik olarak işlemesini ve 6563 sayılı Elektronik Ticaretin Düzenlenmesi Hakkında Kanun’a uygun olarak tarafıma ticari elektronik ileti göndermesini kabul ediyorum.`
        },
        iletisim: {
            title: 'Eureko Sigorta İletişim İzin Metni',
            content: `Eureko Sigorta’nın şimdi ilettiğim ve/veya gelecekte ileteceğim kimlik ve iletişim bilgilerimi reklam, kampanya ve benzeri pazarlama faaliyetlerin yürütülmesi amacıyla elektronik ortamlarda otomatik olarak işlemesini ve 6563 sayılı Elektronik Ticaretin Düzenlenmesi Hakkında Kanun’a uygun olarak tarafıma ticari elektronik ileti göndermesini kabul ediyorum.`
        }
    };

    const handleOpen = (type) => {
        setModalContent(modalContents[type]);
        setOpen(true);
    };

    const handleClose = () => {
        setOpen(false);
    };

    return (
        <div className="form-container">
            <h2>Seyahat Sağlık Sigortası Teklifi Al</h2>
            <p>Seyahatinizde yanınızdayız! Kendiniz ya da başkası için hızlı ve güvenli teklif alın.</p>

            <div className="radio-options">
                <button
                    className={`radio-button ${selectedOption === 'kendim' ? 'selected' : ''}`}
                    onClick={() => setSelectedOption('kendim')}
                >
                    Kendim için
                </button>
                <button
                    className={`radio-button ${selectedOption === 'baskasi' ? 'selected' : ''}`}
                    onClick={() => setSelectedOption('baskasi')}
                >
                    Bir başkası için
                </button>
            </div>

            <form>
                <label>T.C. Kimlik Numaranız (11 Hane)</label>
                <input type="text" placeholder="T.C. Kimlik Numaranız" maxLength="11" />

                <label>Doğum Tarihiniz</label>
                <input type="date" id="start" name="trip-start" placeholder="Yıl/Ay/Gün" />

                <label>E-posta Adresiniz</label>
                <input type="email" placeholder="E-posta Adresiniz" />

                <label>Cep Telefonu Numaranız</label>
                <input type="text" placeholder="5xx-xxx-xxxx" maxLength="10" />

                <div className="checkbox-group">
                    <label
                     style={{ 
                      cursor: 'pointer', 
                      display: 'flex', 
                      alignItems: 'center',
                      userSelect: 'none',
                  }}>
                        <input 
                            type="checkbox" 
                            onChange={() => handleOpen('kvkk')} 
                        />
                       <span style={{color:"#000080"}}>KVKK Aydınlatma metnini</span> &nbsp; okudum ve onaylıyorum.
                    </label>
                    <label
                    style={{ 
                      cursor: 'pointer', 
                      display: 'flex', 
                      alignItems: 'center',
                      userSelect: 'none',
                  }}>
                        <input 
                            type="checkbox" 
                            onChange={() => handleOpen('sozlesme')} 
                        />
                       <span style={{color:"#000080"}}>Kullanıcı Sözleşmesi'ni</span> &nbsp; okudum ve onaylıyorum.
                    </label>
                    <label
                    style={{ 
                      cursor: 'pointer', 
                      display: 'flex', 
                      alignItems: 'center',
                      userSelect: 'none',
                  }}>
                        <input 
                            type="checkbox" 
                            onChange={() => handleOpen('iletisim')} 
                        />
                       <span style={{color:"#000080"}}> İletişim izin metnini </span> &nbsp; okudum ve onaylıyorum.
                    </label>
                </div>

                <Button 
                    type="button" 
                    variant="contained" 
                    onClick={nextStep}  
                    sx={{
                        mt: 2,
                        width: "100%",
                        maxWidth: "400px",
                        backgroundColor: "#273a7e",
                        color: "#fff", 
                        "&:hover": {
                            backgroundColor: "#273a7e",
                        },
                    }} 
                >
                    Devam
                </Button>
            </form>

            {/* Modal */}
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-title"
                aria-describedby="modal-description"
            >
                <Box sx={style}>
                    <Typography id="modal-title" variant="h6" component="h2">
                        {modalContent.title}
                    </Typography>
                    <Typography id="modal-description" sx={{ mt: 2 , fontSize: '0.8rem' }}>
                        {modalContent.content}
                    </Typography>
                    <Box sx={{ display: 'flex', justifyContent: 'flex-end', mt: 2  }}>
                        <Button 
                            variant="contained" 
                            onClick={handleClose}
                            sx={{
                                backgroundColor: "#273a7e",
                                color: "#fff",
                                '&:hover': {
                                    backgroundColor: "#1a2a5e"
                                }
                            }}
                        >
                            Tamam
                        </Button>
                    </Box>
                </Box>
            </Modal>
        </div>
    );
}

export default PersonalInformations;