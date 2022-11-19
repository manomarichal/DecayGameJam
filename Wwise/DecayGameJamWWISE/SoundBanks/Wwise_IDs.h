/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX_ENEMY_DIE = 2121334968U;
        static const AkUniqueID SFX_FALL = 2373831882U;
        static const AkUniqueID SFX_JUMP_AIR = 1503036824U;
        static const AkUniqueID SFX_JUMP_GROUND = 2398483797U;
        static const AkUniqueID SFX_NUT_IMPACT = 1697048511U;
        static const AkUniqueID SFX_PAIN = 1857586793U;
        static const AkUniqueID SFX_WALLSLIDE = 1661693364U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace IN_GAME
        {
            static const AkUniqueID GROUP = 2967546505U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PART1 = 3177314147U;
                static const AkUniqueID PART2 = 3177314144U;
                static const AkUniqueID PART3 = 3177314145U;
                static const AkUniqueID PART4 = 3177314150U;
                static const AkUniqueID PART5 = 3177314151U;
            } // namespace STATE
        } // namespace IN_GAME

        namespace MENU
        {
            static const AkUniqueID GROUP = 2607556080U;

            namespace STATE
            {
                static const AkUniqueID NONE = 748895195U;
                static const AkUniqueID PLAY = 1256202815U;
            } // namespace STATE
        } // namespace MENU

        namespace MUSIC
        {
            static const AkUniqueID GROUP = 3991942870U;

            namespace STATE
            {
                static const AkUniqueID IN_GAME = 2967546505U;
                static const AkUniqueID MENU = 2607556080U;
                static const AkUniqueID NONE = 748895195U;
            } // namespace STATE
        } // namespace MUSIC

    } // namespace STATES

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
