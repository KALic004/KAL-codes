/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/UnitTests/JUnit5TestClass.java to edit this template
 */
package loginmodule;

import java.lang.reflect.Field;
import java.util.ArrayList;
import static org.junit.Assert.assertFalse;
import static org.junit.Assert.assertTrue;
import org.junit.Test;

public class VerifyUserLoginTest {
    @Test
    public void testVerifyUserLoginCredentials() throws Exception {
        VerifyUserLogin verifyUser = new VerifyUserLogin();
        ArrayList<String> testCredentialsList = new ArrayList<>();
        testCredentialsList.add("KimLeviste, kim");
        testCredentialsList.add("AnnBailey, ann");
        testCredentialsList.add("EmberleighRay, lee");
        testCredentialsList.add("EleanorKorvexia, elly");
        
        Field field = VerifyUserLogin.class.getDeclaredField("credentialsList");
        field.setAccessible(true);
        field.set(verifyUser, testCredentialsList);
        
        assertTrue(verifyUser.verifyUserLoginCredentials("KimLeviste", "kim"));
        assertTrue(verifyUser.verifyUserLoginCredentials("AnnBailey", "ann"));
        assertTrue(verifyUser.verifyUserLoginCredentials("EmberleighRay", "lee"));
        assertTrue(verifyUser.verifyUserLoginCredentials("EleanorKorvexia", "elly"));
        assertFalse(verifyUser.verifyUserLoginCredentials("YuukiMichiko", "yuuki"));
        assertFalse(verifyUser.verifyUserLoginCredentials("DahliaStella", "danlia"));
        assertFalse(verifyUser.verifyUserLoginCredentials("KalesterMo", "kal"));
        assertFalse(verifyUser.verifyUserLoginCredentials("YuukiMichiko", "yuuki"));
        assertFalse(verifyUser.verifyUserLoginCredentials("YuukiMichiko", "yuuki"));
    }
    
}
