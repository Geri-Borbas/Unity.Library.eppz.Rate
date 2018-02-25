//
// Copyright (c) 2017 eppz! mobile, Gergely Borbás (SP)
//
// http://www.twitter.com/_eppz
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED,
// INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A
// PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
// HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
// CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE
// OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//

#import "EPPZ_Rate_C++.h"


extern "C"
{
    
    
    void EPPZ_Rate_RequestReviewIfAppropriate()
    {
        if([SKStoreReviewController class])
        { [SKStoreReviewController requestReview]; }
    }

    bool EPPZ_Rate_IsSandboxEnvironment()
    {
        NSURL *receiptURL = [[NSBundle mainBundle] appStoreReceiptURL];
        NSString *receiptURLString = [receiptURL path];
        BOOL isSandboxReceipt =  ([receiptURLString rangeOfString:@"sandboxReceipt"].location != NSNotFound);
        return isSandboxReceipt;
    }

    
}
