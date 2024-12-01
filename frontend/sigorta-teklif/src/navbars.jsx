import React from "react";

const Navbars = () => {
    return(
        <>
          {/* Üst Lacivert Navbar */}
      <div className="top-bar">
      <div className="contact-info">
        <span>0850 222 66 60</span>
        <span>Blog</span>
      </div>
      <div className="right-buttons">
        <span>Eureko WhatsApp</span>
        <span>Şirketiniz İçin Eureko</span>
        <span>EN</span>
      </div>
    </div>

    {/* Beyaz Navbar */}
    <div className="navbar">
      <div className="logo">Eureko</div>
      <div className="nav-links">
        <span>Ürünlerimiz</span>
        <span>Yardım Merkezi</span>
        <span>Yatırımcı İlişkileri</span>
      </div>
      <div className="nav-right">
        <i className="fas fa-search"></i>
        <button className="login-button">Giriş Yap</button>
      </div>
    </div>
    </>
    );
};

export default Navbars;