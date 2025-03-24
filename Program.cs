using System;
using Sodium;

public class WireGuardKeyGenerator
{
    public static (string PrivateKey, string PublicKey) GenerateKeys()
    {
        // Generate a Curve25519 private key (32 bytes)
        var privateKey = PublicKeyAuth.GenerateKeyPair().PrivateKey[..32];

        // Derive the public key from the private key
        var publicKey = ScalarMult.Base(privateKey);

        // Convert to Base64 for display
        string privateKeyBase64 = Convert.ToBase64String(privateKey);
        string publicKeyBase64 = Convert.ToBase64String(publicKey);

        return (privateKeyBase64, publicKeyBase64);
    }

    public static void Main(string[] args)
    {
        var (privateKey, publicKey) = GenerateKeys();

        Console.WriteLine("WireGuard Key Pair Generator");
        Console.WriteLine("------------------------------");
        Console.WriteLine($"Private Key: {privateKey}");
        Console.WriteLine($"Public Key:  {publicKey}");
        Console.WriteLine("------------------------------");
    }
}
