import React, { useState } from 'react';
import './App.css';
import PersonalInformations from './components/personal-informations';
import Box from "@mui/material/Box";
import Navbars from './navbars';
import Footer from "./Footer";
import SmsVerification from './components/sms-verification';
import TravelInfo from './components/travel-info';

function App() {
  const [currentStep, setCurrentStep] = useState(1);

  const nextStep = () => {
    if (currentStep < 6) setCurrentStep(currentStep + 1);
  };

  return (
    <div className="container">
      
      <Navbars /> {/* Navbar en üstte olacak */}      
      <div className="main-content">
        
        
        {/* Adım Listesi */}
        <div className="step-list">
          {[1, 2, 3, 4, 5, 6].map((step) => (
            <div
              key={step}
              className={`step-item ${currentStep === step ? 'active' : ''}`}
              onClick={() => setCurrentStep(step)}
            >
              <div className="step-circle">{step}</div>
              {step === 1 && <span>Kişisel Bilgiler</span>}
              {step === 2 && <span>SMS Doğrulaması</span>}
              {step === 3 && <span>Seyahat Bilgileri</span>}
              {step === 4 && <span>Teminatlar</span>}
              {step === 5 && <span>Teklif</span>}
              {step === 6 && <span>Satın Al</span>}
            </div>
          ))}
        </div>

          {/* İçerik - Merkezde Değişen Bölüm */}
          {currentStep === 1 && <PersonalInformations nextStep={nextStep} />}
          {currentStep === 2 && <SmsVerification nextStep={nextStep} />}
          {currentStep === 3 && <TravelInfo nextStep={nextStep} />}
          {/* Diğer adımlar için ayrı bileşenler eklenebilir */}

      </div>

      <Box component="Footer" sx={{ pt: 2, bgcolor: "#f9f9f9", mt: 'auto' }}>
        <Footer />
      </Box>
    </div>
  );
}

export default App;
